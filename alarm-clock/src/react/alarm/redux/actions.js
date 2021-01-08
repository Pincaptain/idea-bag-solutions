import axios from 'axios';

import {
  GET_ALARMS,
  GET_ALARM,
  CREATE_ALARM,
  UPDATE_ALARM,
  DELETE_ALARM
} from './types';

const root = 'http://localhost:8000';

export const getAlarms = () => (dispatch) => {
  // noinspection JSUnusedLocalSymbols
  axios
    .get(root)
    .then(result => {
      dispatch({
        type: GET_ALARMS,
        payload: result.data
      });
    })
    .catch(error => {
      dispatch({
        type: GET_ALARMS,
        payload: []
      });
    });
};

export const getAlarm = (id) => (dispatch) => {
  // noinspection JSUnusedLocalSymbols
  axios
    .get(`${root}/${id}`)
    .then(result => {
      dispatch({
        type: GET_ALARM,
        payload: result.data
      });
    })
    .catch(error => {
      dispatch({
        type: GET_ALARM,
        payload: null
      });
    });
};

export const createAlarm = (alarm) => (dispatch) => {
  // noinspection JSUnusedLocalSymbols
  axios
    .post(root, alarm)
    .then(result => {
      dispatch({
        type: CREATE_ALARM,
        payload: result.data
      });
    })
    .catch(error => {
      dispatch({
        type: CREATE_ALARM,
        payload: null
      })
    });
};

export const updateAlarm = (id, alarm) => (dispatch) => {
  // noinspection JSUnusedLocalSymbols
  axios
    .put(`${root}/${id}`, alarm)
    .then(result => {
      dispatch({
        type: UPDATE_ALARM,
        payload: result.data
      });
    })
    .catch(error => {
      dispatch({
        type: UPDATE_ALARM,
        payload: null
      });
    });
};

export const deleteAlarm = (id) => (dispatch) => {
  // noinspection JSUnusedLocalSymbols
  axios
    .delete(`${root}/${id}`)
    .then(result => {
      dispatch({
        type: DELETE_ALARM
      });
    })
    .catch(error => {
      dispatch({
        type: DELETE_ALARM,
      });
    });
};