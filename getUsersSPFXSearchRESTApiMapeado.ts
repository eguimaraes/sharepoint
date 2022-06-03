#getUserMapeado para  objeto

import { Version } from '@microsoft/sp-core-library';
import {
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-property-pane';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';
import { IReadonlyTheme } from '@microsoft/sp-component-base';
import { escape, times } from '@microsoft/sp-lodash-subset';

import styles from './MostraPerfilSharePointWebPart.module.scss';
import * as strings from 'MostraPerfilSharePointWebPartStrings';



import { SPHttpClient, SPHttpClientConfiguration, SPHttpClientResponse, ODataVersion, ISPHttpClientConfiguration } from '@microsoft/sp-http';
import { IODataUser, IODataWeb } from '@microsoft/sp-odata-types';

export interface IDados {
  value: IDado;
}

export interface IDado {
  PrimaryQueryResult: object;
}



export interface IMostraPerfilSharePointWebPartProps {
  description: string;
}

export default class MostraPerfilSharePointWebPart extends BaseClientSideWebPart<IMostraPerfilSharePointWebPartProps> {

  private _isDarkTheme: boolean = false;
  private _environmentMessage: string = '';

  

  private _getListData(): Promise<IDado> {
    const spSearchConfig: ISPHttpClientConfiguration = {
      defaultODataVersion: ODataVersion.v3
    };    
   
    const clientConfigODataV3: SPHttpClientConfiguration = SPHttpClient.configurations.v1.overrideWith(spSearchConfig);


    return this.context.spHttpClient.get(this.context.pageContext.web.absoluteUrl + `/_api/search/query?querytext='*'&SelectProperties='AboutMe,AccountName,UserProfile_GUID,LastModifiedTime,OriginalPath,Path,PreferredName,ServiceApplicationID,WorkEmail,PictureURL,SipAddress,UserLocation,RefinableDate00'&TrimDuplicates=true&SourceId='B09A7990-05EA-4AF9-81EF-EDFAB16C4E31'&rowsperpage=100&RowLimit=300'`, clientConfigODataV3)
      .then((response: SPHttpClientResponse) => {

        let resposta: any = response.json();              

                             
        return resposta;
      });
  }

/*---------------------------obter Dados-----------------------------------------------------------------*/

  private _renderList(item: IDado): void {  
    let html: string = '';
    
    let resultadoBusca: any = item.PrimaryQueryResult;
    
    let linhas: any = resultadoBusca.RelevantResults.Table.Rows;

    var infomacao: any = {
      "PreferredName":"",
      "AboutMe":"",
      "PictureURL":"",
      "Aniversario":""


    };

    
    linhas.map(linha => {           

      linha.Cells.map(dadosV => {

        let campos:any = ["PreferredName","AboutMe","PictureURL","RefinableDate00"];

        
        if (campos.includes(dadosV.Key) && dadosV.Value !== null) {
          
      
          switch (dadosV.Key){
            
                        
            case "PictureURL":
              infomacao.PictureURL = dadosV.Value;
              break;
            
              case "PreferredName":
                infomacao.PreferredName = dadosV.Value;
              break;
            
              case "RefinableDate00":
                infomacao.Aniversario = dadosV.Value;
              break;
              case "AboutMe":
                infomacao.AboutMe = dadosV.Value;
              break;
            
            
            

          }

         


          
          




        }
       
       
       ;

      });

      html += `
      <div>
      <img src='${infomacao.PictureURL}'></br>
      <div>Nome: ${infomacao.PreferredName}</div></br>
      <div>Sobre: ${infomacao.AboutMe}</div></br>
      <div>Aniversario: ${infomacao.Aniversario}</div></div></br></br>`

      infomacao.AboutMe= infomacao.PictureURL = infomacao.PreferredName = infomacao.Aniversario = "";


    });

    
 
 
  
    const listContainer: Element = this.domElement.querySelector('#spListContainer');
    listContainer.innerHTML = html;
  }

  private _renderListAsync(): void {
    this._getListData()
      .then((response) => {
        this._renderList(response);
      });
  }
  
  /*--------------------------------------------------------------------------------------------------------------------------------------*/
  

  /**teste de uso da rest api de busca*/

  protected testeRestApi(): void{
  
const spHttpClient: SPHttpClient = this.context.spHttpClient;
const currentWebUrl: string = this.context.pageContext.web.absoluteUrl;

//GET current web info
spHttpClient.get(`${currentWebUrl}/_api/web`, SPHttpClient.configurations.v1).then((response: SPHttpClientResponse) => {

    response.json().then((web: IODataWeb) => {

        console.log(web.Url);
    });
});

//GET current user information from the User Information List
spHttpClient.get(`${currentWebUrl}/_api/web/currentuser`, SPHttpClient.configurations.v1).then((response: SPHttpClientResponse) => {

    response.json().then((user: IODataUser) => {

        console.log(user.LoginName);
    });
});

//GET current user information from the User Profile Service
spHttpClient.get(`${currentWebUrl}/_api/SP.UserProfiles.PeopleManager/GetMyProperties`, SPHttpClient.configurations.v1).then((response: SPHttpClientResponse) => {

    response.json().then((userProfileProps: any) => {

        console.log(userProfileProps);
    });
});





  }
  

  protected testSearchRestApi(): void{
  
const spHttpClient: SPHttpClient = this.context.spHttpClient;
const currentWebUrl: string = this.context.pageContext.web.absoluteUrl;


const spSearchConfig: ISPHttpClientConfiguration = {
  defaultODataVersion: ODataVersion.v3
};


const clientConfigODataV3: SPHttpClientConfiguration = SPHttpClient.configurations.v1.overrideWith(spSearchConfig);


spHttpClient.get(`${currentWebUrl}/_api/search/query?querytext='*'&SelectProperties='AccountName'&Sourceid='B09A7990-05EA-4AF9-81EF-EDFAB16C4E31'`, clientConfigODataV3).then((response: SPHttpClientResponse) => {

  response.json().then((responseJSON: any) => {

    let linhas: any = responseJSON.PrimaryQueryResult.RelevantResults.Table.Rows;
    
    linhas.map(linha => {
    
      linha.Cells.map(dados => {
        
        
        
        console.log(dados);
      });

      
    
    
    }
     
    
    );


  
  });
});


  }

/*--------------------------------------------------------------------------------------------------------------------------------------*/



  protected onInit(): Promise<void> {
    this._environmentMessage = this._getEnvironmentMessage();

    return super.onInit();
  }

  public render(): void {
    this.domElement.innerHTML = `
    
    <div id="spListContainer" />
    
    `;
    this._renderListAsync();

    //this.testSearchRestApi();
   
  }

  private _getEnvironmentMessage(): string {
    if (!!this.context.sdks.microsoftTeams) { // running in Teams
      return this.context.isServedFromLocalhost ? strings.AppLocalEnvironmentTeams : strings.AppTeamsTabEnvironment;
    }

    return this.context.isServedFromLocalhost ? strings.AppLocalEnvironmentSharePoint : strings.AppSharePointEnvironment;
  }

  protected onThemeChanged(currentTheme: IReadonlyTheme | undefined): void {
    if (!currentTheme) {
      return;
    }

    this._isDarkTheme = !!currentTheme.isInverted;
    const {
      semanticColors
    } = currentTheme;
    this.domElement.style.setProperty('--bodyText', semanticColors.bodyText);
    this.domElement.style.setProperty('--link', semanticColors.link);
    this.domElement.style.setProperty('--linkHovered', semanticColors.linkHovered);

  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
