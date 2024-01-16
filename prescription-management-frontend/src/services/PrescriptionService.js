import axios from 'axios';

const API_URL = 'http://localhost:5000/prescriptions/'; 

const createPrescription = async (prescriptionData) => {
    return await axios.post(API_URL, prescriptionData);
};

// methods will be added

export default {
    createPrescription
};
