import React from 'react';
import {Route, Switch} from "react-router-dom";
import MainSideBar from "../../components/sidebar/MainSideBar";
import Elements from "../../components/elements/Elements";
import './HomePage.css';
import MenusPage from "../MenusPage/MenusPage";

function HomePage(props: HomePagePropType) {
    return (
        <div className={`home-container`}>
            <MainSideBar/>
            <Switch>
                <div className={`content`}>
                    <Route exact path={`/`}>
                        {/*<Dashboard/>*/}
                        <Elements/>
                    </Route>
                    <Route path={`/menus`}><MenusPage/></Route>
                    <Route path={`/restaurants`}><h1>Restaurants</h1></Route>
                    <Route path={`/employees`}><h1>Employees</h1></Route>
                </div>
            </Switch>
        </div>
    );
}

export default HomePage;

export interface HomePagePropType {

}
