public criaChecklist(): Promise<void>{

    
    return this.context.spHttpClient.get(``, SPHttpClient.configurations.v1)
      .then((response: SPHttpClientResponse) => {
        console.log(response.json());
      })
      .catch((error) => {console.log(error);}).then(()=>{console.log("Rodou");});
    
   


  
  
  }
  
