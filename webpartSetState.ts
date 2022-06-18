import * as React from 'react';
import styles from './TicTacToe.module.scss';
import { ITicTacToeProps } from './ITicTacToeProps';
import { escape } from '@microsoft/sp-lodash-subset';



export interface IValues{

  value: string;

}

export interface IState{value: string;}


export default class Square extends React.Component<IValues,IState> {



  componentDidMount(): void {
  
  }
  
  public setValor() {
  
    const [valuePass,setValue] = React.useState("A");


}
 
 
  render(): React.ReactElement<IValues> {
    const { value } = this.props;

    


    let a = "";

    try {
      a=this.state.value;
    } catch { a = "O" }
    



      return (
      
       <button
        className="square"
        onClick={() => this.setState({value:new Date().toLocaleTimeString()}) }
      >
        {a}
      </button>
      );
  
    }
 
}
