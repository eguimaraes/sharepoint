import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-property-pane';

import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import { IReadonlyTheme } from '@microsoft/sp-component-base';

import * as strings from 'CriarListaWebPartStrings';

import CriarLista from './components/CriarLista';

import { ICriarListaProps } from './components/ICriarListaProps';


import { SPHttpClient,
  SPHttpClientConfiguration,
   SPHttpClientResponse, 
   ODataVersion, 
   ISPHttpClientConfiguration, 
   ISPHttpClientOptions,/*
   ISPHttpClientBatchOptions,
   SPHttpClientBatch,
ISPHttpClientBatchCreationOptions*/ } from '@microsoft/sp-http';




export interface ICriarListaWebPartProps {
  description: string;
}

export default class CriarListaWebPart extends BaseClientSideWebPart<ICriarListaWebPartProps> {

  private _isDarkTheme: boolean = false;
  private _environmentMessage: string = '';

  private _makeSPHttpClientPOSTRequest(titulo:string,context:any): void {
    // Here, 'this' refers to my SPFx webpart which inherits from the BaseClientSideWebPart class.
    // Since I am calling this method from inside the class, I have access to 'this'.
    const spHttpClient: SPHttpClient = context.spHttpClient;
    const currentWebUrl: string = context.pageContext.web.absoluteUrl;

    const currentTime: string = new Date().toString();
    const spOpts: ISPHttpClientOptions = {
      body: `{ Title: '${titulo} ${currentTime}', BaseTemplate: 100 }`
    };


    spHttpClient.post(`${currentWebUrl}/_api/web/lists`, SPHttpClient.configurations.v1, spOpts)
      .then((response: SPHttpClientResponse) => {
        // Access properties of the response object. 
        console.log(`Status code: ${response.status}`);
        console.log(`Status text: ${response.statusText}`);

        //response.json() returns a promise so you get access to the json in the resolve callback.
        response.json().then((responseJSON: JSON) => {
          console.log(responseJSON);
        });
      });
  }

  public render(): void {
    const element: React.ReactElement<ICriarListaProps> = React.createElement(
      CriarLista,
      {
        description: this.properties.description,
        isDarkTheme: this._isDarkTheme,
        environmentMessage: this._environmentMessage,
        hasTeamsContext: !!this.context.sdks.microsoftTeams,
        userDisplayName: this.context.pageContext.user.displayName,
        criaLista:this._makeSPHttpClientPOSTRequest,
        context:this.context
      }
    );

    ReactDom.render(element, this.domElement);
  }

  protected onInit(): Promise<void> {
    this._environmentMessage = this._getEnvironmentMessage();

    return super.onInit();
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

    if (semanticColors) {
      this.domElement.style.setProperty('--bodyText', semanticColors.bodyText || null);
      this.domElement.style.setProperty('--link', semanticColors.link || null);
      this.domElement.style.setProperty('--linkHovered', semanticColors.linkHovered || null);
    }

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
