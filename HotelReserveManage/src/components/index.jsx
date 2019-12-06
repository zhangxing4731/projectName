import React from 'react';
import webApi from '../webApi';
import { Button, message } from 'antd';

export default class Index extends React.Component{
    constructor(){
        super();
        this.state={
            name: "",
            number: 0,
            isExit: false,
            //createTime:"",
        }
    }
    componentDidMount(){
       
    }
    click() {
        message.info("111");
        webApi.get('http://localhost:50910/test/api/index').then(result => { 
            if (result.flag) {
                if (result.returnValue != null) {
                    this.setState({
                        name:result.returnValue.name,
                        number:result.returnValue.number,
                        isExit:result.returnValue.IsExit,
                        //createTime: result.returnValue.createTime,
                    })
                }
            }
            else
            {
                message.error(result.errorMessage);
                return;
            }
        })
    }

    clickaa() {
        message.info("111");
        webApi.get('http://localhost:50910/test/api/createfiledatabase').then(result => {
            if (result.flag) {
                if (result.returnValue != null) {
                    this.setState({
                        //name: result.returnValue.name,
                        //number: result.returnValue.number,
                        //isExit: result.returnValue.IsExit,
                        //createTime: result.returnValue.createTime,
                    })
                }
            }
            else {
                message.error(result.errorMessage);
                return;
            }
        })
    }

    render(){
        return(
            <div>
                <Button onClick={this.click.bind(this)} type="primary">点击执行</Button>
                <div>{this.state.name}</div>
                <div>{this.state.number}</div>
                <div>{this.state.isExit}</div>

                <Button onClick={this.clickaa.bind(this)} type="primary">点击执行aa</Button>
            </div>
        )
    }
}