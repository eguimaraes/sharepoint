import {
  SPHttpClient,
  SPHttpClientResponse
} from '@microsoft/sp-http';

export interface ISPLists {
  value: ISPList[];
}

export interface ISPList {
  Title: string;
  Id: string;
  link: string;
}

 private _renderList(items: ISPList[]): void {
    let html: string = '';
    items.forEach((item: ISPList) => {
      html += `<a href="${item.link}">${item.Title}</a>  `;
    
    });
  
    const listContainer: Element = this._topPlaceholder.domElement.querySelector('#spListContainer');
    console.log(html);
    listContainer.innerHTML = html;
  }

  private _renderListAsync(): void {
    this._getListData()
      .then((response) => {
        this._renderList(response.value);

        console.log(response.value);
      });
  }

  private _getListData(): Promise<ISPLists> {
    return this.context.spHttpClient.get(this.context.pageContext.web.absoluteUrl + `/_api/web/lists/getbytitle('menu')/items?$orderby=Ordem`, SPHttpClient.configurations.v1)
      .then((response: SPHttpClientResponse) => {
        return response.json();
      });
  }
