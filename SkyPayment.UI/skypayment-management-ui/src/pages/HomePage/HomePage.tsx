import React, {useState} from 'react';
import {Route, Switch} from "react-router-dom";
import MainSideBar from "../../components/sidebar/MainSideBar";
import Elements from "../../components/elements/Elements";
import './HomePage.css';
import MenusPage from "../MenusPage/MenusPage";
import Navbar from "../../components/navbar/Navbar";

function HomePage(props: HomePagePropType) {
    const [sidebarOpen, setSidebarOpen] = useState<boolean>(true);
    return (
        <div className={`home-container`}>
            <Navbar onSideBarStateChange={setSidebarOpen}/>
            <MainSideBar isOpen={sidebarOpen}/>
            <div className={`content ${sidebarOpen ? 'expanded' : ''}`}>
                <Switch>
                    <Route exact path={`/`}>
                        {/*<Dashboard/>*/}
                        <Elements/>
                    </Route>
                    <Route path={`/menus`}><MenusPage/></Route>
                    <Route path={`/restaurants`}><h1>Restaurants</h1></Route>
                    <Route path={`/employees`}><h1>Employees</h1></Route>
                </Switch>
            </div>
        </div>
    );
}

export default HomePage;

export interface HomePagePropType {

}
