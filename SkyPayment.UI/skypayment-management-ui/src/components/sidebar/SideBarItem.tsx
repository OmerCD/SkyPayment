import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import React from 'react';
import './SideBarItem.css'
import {IconDefinition} from "@fortawesome/fontawesome-svg-core";
import {Link, useLocation} from 'react-router-dom';

function SideBarItem(props: SideBarItemPropType) {
    const {pathname} = useLocation();
    return (
        <div className={`sidebar-item-container`}>
            <Link className={`sidebar-item-field ${pathname === props.to ? 'active' : 0}`} to={props.to}>
                <FontAwesomeIcon icon={props.icon}/>
                <label>{props.name}</label>
            </Link>
        </div>
    );
}

export default SideBarItem;

export interface SideBarItemPropType {
    name: string,
    icon: IconDefinition,
    to:string
}
