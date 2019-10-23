import React from 'react';
import { Route } from 'react-router';
import { BrowserRouter, Switch } from 'react-router-dom'
import Layout from './components/Layout';
import Home from './components/Home';
import LogIn from './components/Authentication/LogIn';
import Register from './components/Authentication/Register';
import DisplayBooks from './components/Books/DisplayBooks';
import BookDetail from './components/Books/BookDetail';

export default () => (
    <BrowserRouter>
        <div>  
            <Switch>
                <Layout>
                    <Route exact path='/' component={Home} />
                    <Route path='/login' component={LogIn} />
                    <Route path='/register' component={Register} />
                    <Route exact path='/books' component={DisplayBooks} />
                    <Route path='/books/:id' component={BookDetail}></Route>
                </Layout>
            </Switch>        
        </div>
    </BrowserRouter>
);
