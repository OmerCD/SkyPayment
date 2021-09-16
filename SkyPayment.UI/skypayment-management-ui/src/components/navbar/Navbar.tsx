import React, {useState} from 'react';
import './Navbar.css';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faArrowLeft, faArrowRight, faBars} from "@fortawesome/free-solid-svg-icons";


function Navbar(props:NavbarPropTypes) {
    const [sidebarState, setSidebarState] = useState<boolean>(true);
    return (
        <div className={`navbar-container ${sidebarState ? 'expanded' : ''}`}>
            <div className={`navbar_sidebar-collapse-button`}  onClick={event => {
                props.onSideBarStateChange(!sidebarState);
                setSidebarState(!sidebarState);
            }}>
                <FontAwesomeIcon icon={faBars}/>
            </div>
        </div>
    );
}

export default Navbar;

export interface NavbarPropTypes {
    onSideBarStateChange: (newState:boolean) => void;
}