import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-property-pane';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';
import { IReadonlyTheme } from '@microsoft/sp-component-base';

import * as strings from 'MostraPaisesReactWebPartStrings';
import MostraPaisesReact from './components/MostraPaisesReact';
import { IMostraPaisesReactProps } from './components/IMostraPaisesReactProps';

import * as bootstrap from "bootstrap";

import {
  SPHttpClient,
  SPHttpClientResponse
} from '@microsoft/sp-http';

export interface Dados {
  value: Dado[];
}

export interface Dado {
  Title: string;
  capital: string;
  continente:string
  Id: string;
  Modified: string;
  AttachmentFiles: object;

}

export interface IMostraPaisesReactWebPartProps {
  description: string;
}

export default class MostraPaisesReactWebPart extends BaseClientSideWebPart<IMostraPaisesReactWebPartProps> {

  private _isDarkTheme: boolean = false;
  private _environmentMessage: string = '';

  private _renderList(items: Dado[]): void {
    let html: string = `      
      
      `;
    items.forEach((item: Dado) => {

      html += `
      <div class="card" style="width: 18rem;">
  <img class="card-img-top" src="${(item.AttachmentFiles[0]!=null)?item.AttachmentFiles[0].ServerRelativeUrl:""}" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">${item.Title}</h5>
    <p class="card-text">${item.capital}</p>
    <a href="https://www.google.com/search?q=${item.Title}" class="btn btn-primary">Pesquisar ${item.Title} no Google</a>
  </div>
</div>
      
      `;
   
     
    });
    
      const listContainer: Element = this.domElement.querySelector('#paises');
     console.log(html);     
      listContainer.innerHTML = html;     
      
    }
  
    private _renderListAsync(): void {
      this._getListData()
        .then((response) => {
          this._renderList(response.value);
  
          
        });
    }
  
    private _getListData(): Promise<Dados> {
      return this.context.spHttpClient.get(this.context.pageContext.web.absoluteUrl + `/_api/web/lists/getbytitle('paises')/items?$orderby=Title&$select=AttachmentFiles,capital,Title,continente,Modified&$expand=AttachmentFiles`, SPHttpClient.configurations.v1)
        .then((response: SPHttpClientResponse) => {
          
          
  
          return response.json();
        });
    }


  protected onInit(): Promise<void> {
    this._environmentMessage = this._getEnvironmentMessage();

    return super.onInit();
  }

  public render(): void {
    require('../../../node_modules/bootstrap/dist/css/bootstrap.min.css');
    this._renderListAsync();
    const element: React.ReactElement<IMostraPaisesReactProps> = React.createElement(
      MostraPaisesReact,
      {
        description: this.properties.description,
        isDarkTheme: this._isDarkTheme,
        environmentMessage: this._environmentMessage,
        hasTeamsContext: !!this.context.sdks.microsoftTeams,
        userDisplayName: this.context.pageContext.user.displayName
      }
    );

    ReactDom.render(element, this.domElement);
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

  protected onDispose(): void {
    ReactDom.unmountComponentAtNode(this.domElement);
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
