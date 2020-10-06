import React, {useState} from 'react';
import Navigation from "./components/routing/Navigation";
import appsettings from './appsettings.json'
import {AppSettingsContext} from "./context/AppSettingsContext";
import {AuthContext} from "./context/AuthContext";
import {RequestContext} from "./context/RequestContext";
import axios from "axios";

function App() {
    const [token, setToken] = useState(JSON.parse(localStorage.getItem('token'))?.token);
    return (
        <AppSettingsContext.Provider value={appsettings}>
            <AuthContext.Provider value={{token, setToken}}>
                <RequestContext.Provider
                    value={axios.create({baseURL: appsettings.apiAddress, headers: {Authorization: 'Bearer ' + token}})}>
                    <Navigation/>
                </RequestContext.Provider>
            </AuthContext.Provider>
        </AppSettingsContext.Provider>
    );
}

export default App;
