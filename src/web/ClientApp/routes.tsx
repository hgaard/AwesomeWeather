import * as React from 'react';
import { Router, Route, HistoryBase } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Upload } from './components/Upload';
import { Chart } from './components/Chart'

export default <Route component={ Layout }>
    <Route path='/' components={{ body: Home }} />  
    <Route path='/upload' components={{ body: Upload }} />       
    <Route path='/chart' components={{ body: Chart }} />    
</Route>;

// Allow Hot Module Reloading
declare var module: any;
if (module.hot) {
    module.hot.accept();
}
