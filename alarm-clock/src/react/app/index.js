import React from 'react';
// noinspection ES6CheckImport
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline/CssBaseline";
import useMediaQuery from '@material-ui/core/useMediaQuery';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import Navigation from "../common/layout/Navigation";
import Alarm from "../alarm";

/**
 * Represents the root of the react application.
 * @returns Root JSX view
 */
function App() {
  const prefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)');

  // noinspection JSValidateTypes
  /**
   * Application preferred theme.
   * Currently set to prefer dark mode.
   * @type {Theme}
   */
  const theme = React.useMemo(
    () =>
      createMuiTheme({
        palette: {
          type: prefersDarkMode ? 'dark' : 'light',
        },
      }),
    [prefersDarkMode],
  );

  return (
    <ThemeProvider theme={theme}>
      <Router>
        <CssBaseline />
        <Navigation />
        <Switch>
          <Route path="/">
            <Alarm />
          </Route>
        </Switch>
      </Router>
    </ThemeProvider>
  );
}

export default App;