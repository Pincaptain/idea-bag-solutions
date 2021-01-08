import { createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';

import reducer from './reducer';

const initialState = {};

const middleware = [thunk];

// noinspection JSCheckFunctionSignatures
/**
 * Create the initial redux store.
 * @type {*}
 */
const store = createStore(
  reducer,
  initialState,
  composeWithDevTools(applyMiddleware(...middleware))
);

export default store;