import React from 'react';
import './App.css';
import { BrowserRouter, Route, Switch   } from 'react-router-dom';
import Home from './Components/Home';

function App() {
 
  return (
    <div className="wrapper">
    <BrowserRouter>
        <Switch>
          <Route path="/"   exact component={Home} />
        </Switch>
      </BrowserRouter> 
      </div>
  );
}

export default App;
