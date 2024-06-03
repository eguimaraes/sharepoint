//https://learn.microsoft.com/en-us/sharepoint/dev/spfx/web-parts/get-started/connect-to-sharepoint

private _getListData(): Promise<ISPLists> {
  return this.context.spHttpClient.get(`${this.context.pageContext.web.absoluteUrl}/_api/web/lists?$filter=Hidden eq false`, SPHttpClient.configurations.v1)
    .then((response: SPHttpClientResponse) => {
      return response.json();
    })
    .catch(() => {});
}
