import axios from 'axios';

const API_URL = 'http://localhost:5000/medicines/'; 

const searchMedicines = async (searchTerm) => {
    return await axios.get(API_URL + 'search', { params: { query: searchTerm } });
};

export default {
    searchMedicines
};
