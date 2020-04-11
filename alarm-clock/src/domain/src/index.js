const express = require('express');

import { createDatabase } from './models/alarms';

const app = express();
const port = 8000;

// Create the alarms database
createDatabase();

// TODO - Setup the routes

// TODO - Start the server

app.get('/', (req, res) => {
    return res.send('Hello World!');
});

app.post('/add', (req, res) => {

});

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`));