import React from "react";
import { Route, Switch } from 'react-router-dom';

import './app.css';
import SessionsPage from "pages/sessions/sessions.page";
import SessionPage from "pages/session/session.page";

const App = () => {
  return (
    <div className="App">
        <Route exact path="/" component={SessionsPage} />
        <Route exact path="/session/:sessionId" component={SessionPage}/>
    </div>
  );
}

export default App;
