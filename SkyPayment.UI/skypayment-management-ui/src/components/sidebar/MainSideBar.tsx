import React from 'react';
import './MainSideBar.css'
import SideBarItem from "./SideBarItem";
import {useAppSelector} from "../../app/hooks";
import {selectUserInfo} from "../../features/session-info/userInfoSlice";
import {faScroll, faUtensils, faUsers, faHome} from '@fortawesome/free-solid-svg-icons'


function MainSideBar(props : MainSideBarPropType) {
    const userInfo = useAppSelector(selectUserInfo);
    return (
        <div className={`sidebar-container`}>
            <div className={`user-info-container`}>
                <label className={`user-info_name`}>{userInfo.userInfo.username}</label>
            </div>
            <div className={`sidebar-items`}>
                <SideBarItem name={'Ana Sayfa'} icon={faHome} to={`/`}/>
                <SideBarItem name={'Restoranlar'} icon={faUtensils} to={`/restaurants`}/>
                <SideBarItem name={'Menüler'} icon={faScroll} to={`/menus`}/>
                <SideBarItem name={'Çalışanlar'} icon={faUsers} to={`/employees`}/>
            </div>
        </div>
    );
}

export default MainSideBar;


export interface MainSideBarPropType {

};
