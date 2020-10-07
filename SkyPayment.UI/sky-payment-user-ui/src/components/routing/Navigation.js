import React from "react";
import {BrowserRouter as Router} from "react-router-dom";
import Switcher from "./Switcher";
import Navbar from "./navbar/Navbar";

function Navigation(){
    return(
        <Router>
            <Navbar/>
            <Switcher/>
        </Router>
    )
}

export default Navigation
