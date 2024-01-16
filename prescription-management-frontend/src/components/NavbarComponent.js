import React from 'react';
import { Link } from 'react-router-dom';

function NavbarComponent() {
    return (
        <nav>
            <ul>
                <li>
                    <Link to="/">Login</Link>
                </li>
                <li>
                    <Link to="/prescriptions">Prescriptions</Link>
                </li>
                <li>
                    <Link to="/medicines">Medicine Lookup</Link>
                </li>
                {/* Add more navigation links as needed */}
            </ul>
        </nav>
    );
}

export default NavbarComponent;
