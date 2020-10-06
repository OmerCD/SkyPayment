import React from "react";
import {Menu, Sidebar, Icon, Segment} from "semantic-ui-react";
import {Route, Switch} from "react-router-dom";
import AddRestaurantPage from "./AddRestaurantPage";
import styled, {css} from "styled-components";
import {useAppSettings} from "../../context/AppSettingsContext";
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
