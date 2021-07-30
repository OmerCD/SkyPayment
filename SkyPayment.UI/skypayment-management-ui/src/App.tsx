import React from 'react';
import './App.scss';
import {useAuthService} from "./hooks/auth-service";
import {Redirect, Route, Switch} from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage";
import {useSelector} from "react-redux";
import {selectAuthenticationState} from "./features/session-info/userInfoSlice";

function App() {
    const isAuthenticated = useSelector(selectAuthenticationState);
    return (
        <div>
            <Switch>
                <Route exact path={'/'}>
                    {isAuthenticated ? <h1>Welcome</h1> : <Redirect to={`/login`}/>  }
                </Route>
                <Route exact path={`/login`}>
                    <LoginPage/>
                </Route>
            </Switch>
        </div>
    );
}

export default App;
