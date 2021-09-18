import React from 'react';
import './App.scss';
import {Redirect, Route, Switch} from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage";
import {useSelector} from "react-redux";
import {selectAuthenticationState} from "./features/session-info/userInfoSlice";
import HomePage from "./pages/HomePage/HomePage";

function App() {
    const isAuthenticated = useSelector(selectAuthenticationState);
    return (
        <>
            <Switch>
                <Route exact path={'/'}>
                    {isAuthenticated ? <HomePage/> : <Redirect to={`/login`}/>}
                </Route>
                <Route exact path={`/login`}>
                    <LoginPage/>
                </Route>
                <Route path={'/'}>
                    <HomePage/>
                </Route>

            </Switch>
        </>
    );
}

export default App;
