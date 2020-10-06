import {withRouter, Route, Switch} from "react-router-dom";
import React from "react";
import LoginPage from "../../pages/Login/LoginPage";
import {useAuth} from "../../context/AuthContext";
import AuthenticationService from "../../services/AuthenticationService";
import Homepage from "../../pages/Home/HomePage";
import RestaurantPage from "../../pages/Restaurant/RestaurantPage";
import AddRestaurantPage from "../../pages/Restaurant/AddRestaurantPage";

function Switcher() {
    const authenticationService = new AuthenticationService(useAuth());
    const token = authenticationService.getToken();
    let content;
    if(token){
        content = (
            <>
                <Route exact path='/'>
                    <Homepage/>
                </Route>
                <Route path='/restaurants/list'>
                    <RestaurantPage/>
                </Route>
                <Route path='/menus/list'>

                </Route>
            </>
        )
    }
    else{
        content = (
            <Route path='/'>
                <LoginPage/>
            </Route>
        )
    }
    return (
        <Switch>
            {content}
        </Switch>
    )
}

export default withRouter(Switcher);
