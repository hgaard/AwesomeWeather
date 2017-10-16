import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Upload } from './components/Upload';
import { Chart } from './components/Chart'

export const routes = <Layout>
    <Route path='/' component={ Home } />  
    <Route path='/upload' component={ Upload } />       
    <Route path='/chart' component={ Chart } />    
</Layout>;

// Allow Hot Module Reloading
declare var module: any;
if (module.hot) {
    module.hot.accept();
}
