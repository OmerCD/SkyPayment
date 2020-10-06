import React, {useEffect, useState} from "react";
import {withRouter, useLocation, Link} from "react-router-dom";
import {Button, Menu, Segment} from "semantic-ui-react";
import {useAuth} from "../../../context/AuthContext";
import AuthenticationService from "../../../services/AuthenticationService";
import {useAppSettings} from "../../../context/AppSettingsContext";

function Navbar(props) {
    const authContext = useAuth();
    const authService = new AuthenticationService(authContext);
    const {navbarHeight} = useAppSettings();
    const [location, setLocation] = useState(useLocation().pathname);
    const [isAuthenticated, setIsAuthenticated] = useState(authService.getToken() !== null);
    useEffect(() => {
        setIsAuthenticated(authService.getToken() !== null);
    }, [authService.getToken()])
    useEffect(() => {
        setLocation(props.location.pathname);
    }, [props.location.pathname]);
    if (!isAuthenticated) {
        return <></>
    }
    const changeLocation = (e) => {
        props.history.push(e.target.getAttribute('to'));
    }
    const logout = () => {
        authService.logout();
    }
    return (
        <Segment inverted style={{height: navbarHeight, marginBottom: 0, borderRadius:0, paddingTop:'2px'}}>
            <Menu inverted pointing secondary size={"small"}>
                <Menu.Item
                    to='/'
                    name='home'
                    active={location === '/home' || location === '/'}
                    onClick={changeLocation}>
                    Ana Sayfa
                </Menu.Item>
                <Menu.Item
                    to='/order/list'
                    name='orders'
                    active={location.startsWith('/order')}
                    onClick={changeLocation}>
                    Siparişler
                </Menu.Item>
                <Menu.Menu position={"right"}>
                    <Menu.Item>
                        <Button basic inverted onClick={logout}>Çıkış</Button>
                    </Menu.Item>
                </Menu.Menu>
            </Menu>
        </Segment>
    )
}

export default withRouter(Navbar);
