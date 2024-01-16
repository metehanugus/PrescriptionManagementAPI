import React, { useState } from 'react';
import AuthService from '../services/AuthService';

function LoginComponent(props) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            await AuthService.login(username, password);
            props.history.push('/prescriptions'); // Redirect to prescriptions page after login
        } catch (error) {
            setErrorMessage('Login failed. Please check your credentials.');
        }
    };

    return (
        <div>
            <form onSubmit={handleLogin}>
                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button type="submit">Login</button>
                {errorMessage && <p>{errorMessage}</p>}
            </form>
        </div>
    );
}

export default LoginComponent;
