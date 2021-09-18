import React, {useEffect, useState} from 'react';
import './TablePagination.css'
import {faBackward, faFastBackward, faFastForward, faForward} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

function TablePagination(props: TablePaginationPropTypes) {
    const [page, setPage] = useState<number>(props.currentPage);
    const [data, setData] = useState<number[]>([]);
    const increasePage = () => {
        setPage(page + 1);
        return page + 1;
    }
    const decreasePage = () => {
        setPage(page - 1);
        return page - 1;
    }
    useEffect(() => {
        const set = new Set<number>();
        set.add(page)
        for (let i=1; i <= 3; i++){
            set.add(page-i);
            set.add(page+i);
        }
        setData(Array.from(set).filter(x=> x > 0 && x <= props.maxPage).sort((a,b) => a > b ? 1 : -1))
    }, [page])
    const pageNumbers = data.map(number => {
        return(
            <TablePaginationItem key={number} page={number} requestFunction={(nb)=>{setPage(nb); props.requestFunction(number)}} currentPage={page}/>
        )
    })
    return (
        <div className={`pagination-container`}>
            <TablePaginationItemSpecial itemType={PaginationItemType.First} requestFunction={() => {
                setPage(1);
                props.requestFunction(1)
            }} page={1}/>
            {page !== 1 && <TablePaginationItemSpecial itemType={PaginationItemType.Previous} requestFunction={() => {
                props.requestFunction(decreasePage())
            }} page={-1}/>}
            {pageNumbers}
            {page !== props.maxPage &&
            <TablePaginationItemSpecial itemType={PaginationItemType.Next} requestFunction={() => {
                props.requestFunction(increasePage())
            }} page={-1}/>}
            <TablePaginationItemSpecial itemType={PaginationItemType.Last} requestFunction={() => {
                setPage(props.maxPage);
                props.requestFunction(props.maxPage)
            }} page={props.maxPage}/>
        </div>
    );
}

export default TablePagination;

export interface TablePaginationPropTypes {
    maxPage: number,
    maxItemPerPage: number
    currentPage: number
    requestFunction: (page: number) => void
}

function TablePaginationItem({page, requestFunction, currentPage}: TablePaginationItemPropTypes) {
    return (
        <div onClick={() => requestFunction(page)}
             className={`pagination-item ${currentPage === page ? 'active' : ''}`}>{page}</div>
    )
}

export interface TablePaginationItemPropTypes {
    page: number
    requestFunction: (page: number) => void
    currentPage: number
}

function TablePaginationItemSpecial({itemType, page, requestFunction}: TablePaginationItemSpecialPropTypes) {
    let iconElement;
    switch (itemType) {
        case PaginationItemType.First:
            iconElement = faFastBackward
            break;
        case PaginationItemType.Last:
            iconElement = faFastForward
            break;
        case PaginationItemType.Next:
            iconElement = faForward
            break;
        case PaginationItemType.Previous:
            iconElement = faBackward
            break;
    }
    return (
        <div className={`pagination-item`} onClick={() => requestFunction(page)}><FontAwesomeIcon icon={iconElement}/></div>
    )
}

export interface TablePaginationItemSpecialPropTypes {
    itemType: PaginationItemType
    requestFunction: (page: number) => void
    page: number
}

export enum PaginationItemType {
    First,
    Last,
    Next,
    Previous
}