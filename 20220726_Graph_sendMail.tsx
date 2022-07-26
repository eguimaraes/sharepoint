import * as React from 'react';
import styles from './GraphSendMail.module.scss';
import { IGraphSendMailProps } from './IGraphSendMailProps';
import { escape } from '@microsoft/sp-lodash-subset';
import { MSGraphClient } from '@microsoft/sp-http';
import * as MicrosoftGraph from '@microsoft/microsoft-graph-types';

export default class GraphSendMail extends React.Component<IGraphSendMailProps, {}> {
  
public assunto:string='';

public mensgaem:string='';

public para: string='';

public msg:any= {
  "message": {
      "subject":"Tetse44",
      "body": {
          "contentType": "Text",
          "content": "teste de mesggegege"
      },
      "toRecipients": [
        {"emailAddress": {"address": ""}}
          
      ]
  }
}


  
public handleAssunto=(e)=>{this.msg.message.subject=e.target.value}

public handleMessagem=(e)=>{this.msg.message.body.content=e.target.value}

public handlePara=(e)=>{this.msg.message.toRecipients[0]["emailAddress"]["address"]=e.target.value}

public handleBotao=(e)=>{this.GraphSendMail(this.msg)}
 
  
  public GraphSendMail(msgObj):void {
   
       
    
    
  console.log(this.msg);
      
    this.props.contexto.msGraphClientFactory
    .getClient()
    .then((client: MSGraphClient): void => {      
      client
        .api('/me/sendMail')
        .post(msgObj,(error, response: any, rawResponse?: any) =>{         
         
        
          if (error) {  
            this.setState({  
              statusMessage: { isShowMessage: true, message: error.message, messageType: 1 }  
            });  
          }  
           //Set Success Message Bar after Sending Email  
          else {  
            this.setState({  
              statusMessage: { isShowMessage: true, message: "Email Sent using MS Graph", messageType: 4 }  
            });  
          }  
        
        console.log(response);
        
        
        }
          
          );
    });



  }


  public handleChange(e){

   console.log(e.target.value);

  }




 

  componentDidCatch(error: Error, errorInfo: React.ErrorInfo): void {
    
  }

  componentWillMount(): void {

   
  
  }

  
  
  public render(): React.ReactElement<IGraphSendMailProps> {
    const {
      description,
      isDarkTheme,
      environmentMessage,
      hasTeamsContext,
      userDisplayName,
      contexto
    } = this.props;

    return (
      <div>
       <div> Para: <input type='text' onChange={this.handlePara}></input></div>
       <div> Assunto: <input type='text' onChange={this.handleAssunto}></input></div>
       <div> Mensagem: <input type='text' onChange={this.handleMessagem}></input></div>

       <div> <input type='Button' onClick={this.handleBotao} value="Enviar"></input></div>
        



      </div>
    );
  }
}
