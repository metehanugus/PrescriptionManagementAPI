import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import LoginComponent from './components/LoginComponent';
import PrescriptionFormComponent from './components/PrescriptionFormComponent';
import MedicineLookupComponent from './components/MedicineLookupComponent';
import NavbarComponent from './components/NavbarComponent';

function App() {
    return (
        <Router>
            <div>
                <NavbarComponent />
                <Switch>
                    <Route path="/" exact component={LoginComponent} />
                    <Route path="/prescriptions" component={PrescriptionFormComponent} />
                    <Route path="/medicines" component={MedicineLookupComponent} />
                    {/* Add more routes as needed */}
                </Switch>
            </div>
        </Router>
    );
}

export default App;
