import React from 'react';

import DateFnsUtils from "@date-io/date-fns";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';
import { CssBaseline } from '@material-ui/core';

import './App.css';
import Alarm from './alarm';
import Navigation from './common/Navigation';

function App() {
    const theme = createMuiTheme({
        palette: {
            type: 'dark',
        },
    });

    return (
        <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <ThemeProvider theme={theme}>
                <CssBaseline />
                <Navigation />
                <Alarm />
            </ThemeProvider>
        </MuiPickersUtilsProvider>
    );
}

export default App;
