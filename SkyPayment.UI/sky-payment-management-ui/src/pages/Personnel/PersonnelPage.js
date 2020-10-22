import React, {useEffect, useState} from "react";
import ListPersonnel from "../../components/restaurant/detail/ListPersonnel";
import PersonnelService from "../../services/PersonnelService";
import {Redirect, Route, Switch, useHistory} from "react-router-dom";
import AddPersonnelPage from "./AddPersonnelPage";
import RestaurantService from "../../services/RestaurantService";

function PersonnelPage() {
    const history = useHistory();
    const personnelService = new PersonnelService();
    const restaurantService = new RestaurantService();
    const [personnels, setPersonnels] = useState([]);
    let restaurants = [];
    useEffect(() => {
        personnelService.getPersonnels().then(response => {
            setPersonnels(response);
        });
    }, []);

    const onAddPersonnel = () => {
        restaurantService.getForDisplay().then(response => {
            history.push({pathname: '/personnels/add', state: {restaurants : response}});
        })
    }
    return (
        <Switch>
            <Redirect from='/personnels' to='/personnels/list' exact/>
            <Route path='/personnels/list'>
                <ListPersonnel personnelList={personnels} onAddPersonnel={onAddPersonnel}/>
            </Route>
            <Route path='/personnels/add'>
                <AddPersonnelPage/>
            </Route>
        </Switch>
    )
}

export default PersonnelPage;