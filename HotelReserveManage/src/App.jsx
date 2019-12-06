import React from 'react';
import ReactDOM from 'react-dom';
import {Button} from 'antd';
import Index from './components/index.jsx'
import './index.less'

ReactDOM.render(
    <div>
        <Button type='primary'>hello world</Button>
        <div className={'a'}>123</div> 
        <Index/>
    </div>,
    document.getElementById('app')
)