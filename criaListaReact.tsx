import * as React from 'react';
import styles from './CriarLista.module.scss';
import { ICriarListaProps } from './ICriarListaProps';
import { escape } from '@microsoft/sp-lodash-subset';

export default class CriarLista extends React.Component<ICriarListaProps, {}> {
  
  public listName:string='';
  
  public setName=e=>{

this.listName=e.target.value;


  };

  public salvarDados=()=>{
    
   
  this.props.criaLista(this.listName,this.props.context)
  
  };  
  
  
  public render(): React.ReactElement<ICriarListaProps> {
    const {
      description,
      isDarkTheme,
      environmentMessage,
      hasTeamsContext,
      userDisplayName,
      criaLista
    } = this.props;

    return (
      <section>

        <div>
       
        <input type='text' onChange={this.setName}></input>
        <button onClick={this.salvarDados}>Enviar</button>
        </div>

      </section>
    );
  }
}
