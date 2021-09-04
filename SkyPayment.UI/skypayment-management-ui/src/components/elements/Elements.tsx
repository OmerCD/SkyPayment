import React from 'react';
import './Elements.css'

function Elements() {
    return (
        <div className={`elements-container`}>
            <input/>
            <button>Test</button>
            <select>
                <option>Option 1</option>
                <option>Option 2</option>
                <option>Option 3</option>
            </select>
            <div>
                <input id={`checkbox`} type={`checkbox`}/>
                <label htmlFor={`checkbox`}>CheckBox</label>
            </div>
            <input type={`number`}/>
            <table>
                <tr>
                    <th>What</th>
                    <th>Are</th>
                    <th>You</th>
                </tr>
                <tr>
                    <td>Doing</td>
                    <td>Here</td>
                    <td>Man</td>
                </tr>
                <tr>
                    <td>Shut</td>
                    <td>The</td>
                    <td><button>Fuck</button></td>
                </tr>
                <tr>
                    <td>Up</td>
                    <td>Bitch</td>
                    <td><button>Edit</button><button>Delete</button></td>
                </tr>
            </table>
            <div style={{display:`flex`}}>
                <div>
                    <input id={`radio1`} name={`test`} type={`radio`}/>
                    <label htmlFor={`radio1`}>Radio1</label>
                </div>
                <div>
                    <input id={`radio2`} name={`test`} type={`radio`}/>
                    <label htmlFor={`radio2`}>Radio2</label>
                </div>
                <div>
                    <input id={`radio3`} name={`test`} type={`radio`}/>
                    <label htmlFor={`radio3`}>Radio3</label>
                </div>
            </div>
        </div>
    );
}

export default Elements;
