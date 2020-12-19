import React from 'react'
import { Card } from 'semantic-ui-react'

function MenuItem({ title, subTitle, description,onclick }) {
    return (
        <Card onClick={onclick}>
            <Card.Content header = {title}  meta = {subTitle}/>
            <Card.Content description = {description}/>
        </Card>
    )
}

export default MenuItem;