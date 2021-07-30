import React from 'react';
import './ContentPill.css';

interface ContentPillPropType{
    type:string;
    text:string;
}

function ContentPill(props:ContentPillPropType) {
    return (
        <div>
            <div className={`pill pill_${props.type}`}>
                {props.text}
            </div>
        </div>
    );
}

export default ContentPill;
