import React from 'react';
import './App.scss';
import { Route, Switch, useHistory} from "react-router-dom";
import MenuSelectionPage from "./pages/menu/MenuSelectionPage";
import MenuPage from "./pages/menu/MenuPage";
import {useAppSelector} from "./app/hooks";
import {selectRestaurantId} from "./features/session-info/sessionInfoSlice";

function App() {
    const history = useHistory();
    const restaurantId = useAppSelector(selectRestaurantId);
    const onMenuSelected = (menuId: string) => {
        history.push(`/restaurant/${restaurantId}/menu/${menuId}`);
    }
    return (
        <div>
            <Switch>
                <Route exact path='/restaurant/:restaurantId/:tableId/menu'
                       render={props => <MenuSelectionPage {...props} onMenuSelected={onMenuSelected}/>}/>
                <Route exact path='/restaurant/:restaurantId/menu/:menuId'
                       render={props => <MenuPage {...props}/>}/>
            </Switch>
        </div>
    );
}

export default App;
