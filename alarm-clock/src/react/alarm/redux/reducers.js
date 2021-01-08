import {
  GET_ALARMS,
  GET_ALARM,
  CREATE_ALARM,
  UPDATE_ALARM,
  DELETE_ALARM
} from './types';

/**
 * Alarms redux initial state.
 * @type {{selectedAlarm: null, alarms: []}}
 */
const initialState = {
  alarms: [],
  selectedAlarm: null
};

/**
 * Reducer for Alarms which takes all types in consideration.
 * @param state
 * @param action
 * @return {{selectedAlarm: null, alarms: *}|{selectedAlarm: null, alarms: *[]}|{selectedAlarm: *, alarms: *[]}}
 */
export default function (state = initialState, action) {
  switch (action.type) {
    case GET_ALARMS:
      return {
        ...state,
        alarms: action.payload
      };
    case GET_ALARM:
      return {
        ...state,
        selectedAlarm: action.payload
      };
    case CREATE_ALARM:
      return {
        ...state,
        selectedAlarm: action.payload
      };
    case UPDATE_ALARM:
      return {
        ...state,
        selectedAlarm: action.payload
      };
    case DELETE_ALARM:
      return {
        ...state
      };
    default:
      return {
        ...state
      };
  }
}