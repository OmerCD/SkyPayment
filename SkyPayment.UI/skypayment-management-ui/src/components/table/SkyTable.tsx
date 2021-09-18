import React from 'react';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faEdit, faTrash} from "@fortawesome/free-solid-svg-icons";
import './SkyTable.css';

function SkyTable(props: SkyTablePropTypes) {
    let content = props.content;
    if (props.hasActions) {
        content = props.content.map(x => {
            return {
                ...x,
                actions: (
                    <div key={x.id} className={`menus-table_actions`}>
                        <button className={"btn-edit"} onClick={() => props.onEditClick?.(x.id)}>
                            <FontAwesomeIcon icon={faEdit}/>
                        </button>
                        <button className={`btn-delete`} onClick={() => props.onDeleteClick?.(x.id)}>
                            <FontAwesomeIcon icon={faTrash}/>
                        </button>
                    </div>)
            }
        })
    }
    const mapped = content.map(obj => {
        const keys = Object.keys(obj);
        const values = keys.map(key => {
            if (key !== 'id') { // @ts-ignore
                return obj[key]
            }
        }).filter(x => x !== undefined && x);
        return <tr key={obj.id}>
            {values.map((value, index) => <td key={index}>{value}</td>)}
        </tr>
    })
    return (
        <div className={`menus-table-container`}>
        <table className={`menus-table`}>
            <thead>
            <tr>
                {props.headers.map(header => {
                    return (
                        <th key={header.name}>{header.name}</th>
                    )
                })}
                {props.hasActions ? <th className={`menus-table_actions`}>Aksiyonlar</th> : <></>}
            </tr>
            </thead>
            <tbody>
            {mapped}
            </tbody>
        </table>
        </div>
    );
}

export default SkyTable;

export interface SkyTablePropTypes {
    headers: SkyTableHeader[]
    content: ObjectWithId[]
    hasActions: boolean
    onEditClick?: (id:string) => void
    onDeleteClick?: (id:string) => void
}

export interface SkyTableHeader {
    name: string
}

export interface ObjectWithId {
    id: string
}