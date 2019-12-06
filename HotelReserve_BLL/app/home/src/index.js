import React, { Component } from 'react';
import { render } from 'react-dom';
import App from './App'

const renderDom = Component => {
    render(
        <Component />,
        document.getElementById('app')
    );
}
renderDom(App);