import React, { useState } from 'react';
import MedicineService from '../services/MedicineService';

function MedicineLookupComponent() {
    const [searchTerm, setSearchTerm] = useState('');
    const [medicines, setMedicines] = useState([]);

    const handleSearch = async () => {
        try {
            const response = await MedicineService.searchMedicines(searchTerm);
            setMedicines(response.data);
        } catch (error) {
            // Handle errors
        }
    };

    return (
        <div>
            <input
                type="text"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <button onClick={handleSearch}>Search</button>
            <ul>
                {medicines.map((medicine, index) => (
                    <li key={index}>{medicine}</li>
                ))}
            </ul>
        </div>
    );
}

export default MedicineLookupComponent;
