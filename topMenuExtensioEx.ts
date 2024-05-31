import { Log } from '@microsoft/sp-core-library';
import {
  BaseApplicationCustomizer,
  PlaceholderContent,
  PlaceholderName,
  
} from '@microsoft/sp-application-base';


import * as strings from 'HeaderFooterApplicationCustomizerStrings';

import { SPComponentLoader } from '@microsoft/sp-loader';

import styles from './AppCustomizer.module.scss';
import { escape } from '@microsoft/sp-lodash-subset';

const LOG_SOURCE: string = 'HeaderFooterApplicationCustomizer';

export interface IHeaderFooterApplicationCustomizerProperties {
    testMessage: string;
  Top: string;
  Bottom: string;
  
}

export default class HeaderFooterApplicationCustomizer
  extends BaseApplicationCustomizer<IHeaderFooterApplicationCustomizerProperties> {

    private _topPlaceholder: PlaceholderContent | undefined;
    private _bottomPlaceholder: PlaceholderContent | undefined;
  
    public onInit(): Promise<void> {

      


      Log.info(LOG_SOURCE, `Initialized ${strings.Title}`);
    
      // Wait for the placeholders to be created (or handle them being changed) and then
      // render.
      this.context.placeholderProvider.changedEvent.add(this, this._renderPlaceHolders);
    
      return Promise.resolve();
    }
    private _renderPlaceHolders(): void {
      let cssURL = "https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css";

      SPComponentLoader.loadCss(cssURL);

      SPComponentLoader.loadScript('https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js', {

      globalExportsName: 'jQuery'

    }).catch((error) => {

      console.log("jQuery loader error occurred");

    }).then(() => {

     return SPComponentLoader.loadScript("https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js");

    });


      
      console.log("HelloWorldApplicationCustomizer._renderPlaceHolders()");
      console.log(
        "Available placeholders: ",
        this.context.placeholderProvider.placeholderNames
          .map(name => PlaceholderName[name])
          .join(", ")
      );
    
      // Handling the top placeholder
      if (!this._topPlaceholder) {
        this._topPlaceholder = this.context.placeholderProvider.tryCreateContent(
          PlaceholderName.Top,
          { onDispose: this._onDispose }
        );
    
        // The extension should not assume that the expected placeholder is available.
        if (!this._topPlaceholder) {
          console.error("The expected placeholder (Top) was not found.");
          return;
        }
    
        if (this.properties) {
          let topString: string = this.properties.Top;
          if (!topString) {
            topString = "(Top property was not defined.)";
          }
    
          if (this._topPlaceholder.domElement) {
            this._topPlaceholder.domElement.innerHTML = `
            <nav class="navbar navbar-default">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">Brand</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li class="active"><a href="#">Link <span class="sr-only">(current)</span></a></li>
        <li><a href="#">Link</a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="https://luzdigital.sharepoint.com/sites/LBR/Relatrio%20de%20Inspeo/Forms/AllItems.aspx">Relatotios</a></li>
            <li><a href="#">Another action</a></li>
            <li><a href="#">Something else here</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Separated link</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">One more separated link</a></li>
          </ul>
        </li>
      </ul>
      <form class="navbar-form navbar-left">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Search">
        </div>
        <button type="submit" class="btn btn-default">Submit</button>
      </form>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#">Link</a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Action</a></li>
            <li><a href="#">Another action</a></li>
            <li><a href="#">Something else here</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Separated link</a></li>
          </ul>
        </li>
      </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
           
            
          `;
          }
        }
      }
    
      // Handling the bottom placeholder
      if (!this._bottomPlaceholder) {
        this._bottomPlaceholder = this.context.placeholderProvider.tryCreateContent(
          PlaceholderName.Bottom,
          { onDispose: this._onDispose }
        );
    
        // The extension should not assume that the expected placeholder is available.
        if (!this._bottomPlaceholder) {
          console.error("The expected placeholder (Bottom) was not found.");
          return;
        }
    
        if (this.properties) {
          let bottomString: string = this.properties.Bottom;
          if (!bottomString) {
            bottomString = "(Bottom property was not defined.)";
          }
    
          if (this._bottomPlaceholder.domElement) {
            this._bottomPlaceholder.domElement.innerHTML = `
            <div class="${styles.app}">
              <div class="${styles.bottom}">
                <i class="ms-Icon ms-Icon--Info" aria-hidden="true"></i> ${escape(
                  bottomString
                )}
              </div>
            </div>`;
          }
        }
      }
    }
    private _onDispose(): void {
      console.log('[HelloWorldApplicationCustomizer._onDispose] Disposed custom top and bottom placeholders.');
    }


}
