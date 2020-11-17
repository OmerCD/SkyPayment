import {withRouter, Route, Switch} from "react-router-dom";
import React from "react";
import LoginPage from "../../pages/Login/LoginPage";
import {useAuth} from "../../context/AuthContext";
import AuthenticationService from "../../services/AuthenticationService";
import Homepage from "../../pages/Home/HomePage";
import OrdersPage from "../../pages/Orders/OrdersPage";
import RegisterPage from "../../pages/Register/RegisterPage";

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
                <Route path='/order/list'>
                    <OrdersPage/>
                </Route>
            </>
        )
    }
    else{
        content = (
          <>
              <Route exact path='/'>
                  <LoginPage/>
              </Route>
              <Route path = '/register'>
                  <RegisterPage/>
              </Route>
          </>
        )
    }
    return (
        <Switch>
            {content}
        </Switch>
    )
}

export default withRouter(Switcher);
