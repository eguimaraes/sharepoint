import {
  SPHttpClient,
  SPHttpClientResponse
} from '@microsoft/sp-http';


private _getListData(): Promise<ISPLists> {
  return this.context.spHttpClient.get(this.context.pageContext.web.absoluteUrl + `/_api/web/lists?$filter=Hidden eq false`, SPHttpClient.configurations.v1)
    .then((response: SPHttpClientResponse) => {
      return response.json();
    });
}
  
  import {
  Environment,
  EnvironmentType
} from '@microsoft/sp-core-library';
  
private _renderList(items: ISPList[]): void {
  let html: string = '';
  items.forEach((item: ISPList) => {
    html += `
  <ul class="${styles.list}">
    <li class="${styles.listItem}">
      <span class="ms-font-l">${item.Title}</span>
    </li>
  </ul>`;
  });

  const listContainer: Element = this.domElement.querySelector('#spListContainer');
  listContainer.innerHTML = html;
}
  
  
  private _renderListAsync(): void {
  // Local environment
  if (Environment.type === EnvironmentType.Local) {
    this._getMockListData().then((response) => {
      this._renderList(response.value);
    });
  }
  else if (Environment.type == EnvironmentType.SharePoint ||
           Environment.type == EnvironmentType.ClassicSharePoint) {
    this._getListData()
      .then((response) => {
        this._renderList(response.value);
      });
  }
}
  
  this.domElement.innerHTML = `
  <div class="${ styles.helloWorld }">
    <div class="${ styles.container }">
      <div class="${ styles.row }">
        <div class="${ styles.column }">
          <span class="${ styles.title }">Welcome to SharePoint!</span>
          <p class="${ styles.subTitle }">Customize SharePoint experiences using web parts.</p>
          <p class="${ styles.description }">${escape(this.properties.description)}</p>
          <p class="${ styles.description }">${escape(this.properties.test)}</p>
          <p class="${ styles.description }">Loading from ${escape(this.context.pageContext.web.title)}</p>
          <a href="https://aka.ms/spfx" class="${ styles.button }">
            <span class="${ styles.label }">Learn more</span>
          </a>
        </div>
      </div>
      <div id="spListContainer" />
    </div>
  </div>`;

this._renderListAsync();
  
  
  
