import React from "react";
import {Route, Switch} from "react-router-dom";
import AddRestaurantPage from "./AddRestaurantPage";
import ListRestaurant from "../../components/restaurant/ListRestaurant";

function RestaurantPage() {
    return (
        <>
            <Switch>
                <Route path='/restaurants/list'>
                    <ListRestaurant restaurants={{}}/>
                </Route>
                <Route path='/restaurants/addRestaurant'>
                    <AddRestaurantPage/>
                </Route>
            </Switch>
        </>
    )
}

export default RestaurantPage;
