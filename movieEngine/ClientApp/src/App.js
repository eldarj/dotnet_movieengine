import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { IndexView } from './components/IndexView';
import { Counter } from './components/Counter';

export default class App extends Component {
    static displayName = App.name;

    render() {
      return (
          <Layout>
              <Route exact path='/' component={IndexView} />
              <Route path='/counter' component={Counter} />
          </Layout>
      );
    }
}
