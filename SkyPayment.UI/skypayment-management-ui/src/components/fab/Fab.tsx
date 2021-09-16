import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import {faPlus} from "@fortawesome/free-solid-svg-icons";
import './Fab.css';

function Fab(props:FabPropTypes) {
    const getClassName = () => {
        switch (props.type) {
            case FabColorType.Success:
                return "success"
            case FabColorType.Warning:
                return "warning"
            case FabColorType.Error:
                return "error"
            case FabColorType.Accent:
                return "accent"
        }
    }
    return (
        <div className={`fab-button ${getClassName()}`} onClick={props.onClick}><FontAwesomeIcon icon={faPlus}/></div>
    );
}

export default Fab;

export interface FabPropTypes{
    onClick:()=>void;
    type:FabColorType;
}
export enum FabColorType{
    Success,
    Warning,
    Error,
    Accent
}