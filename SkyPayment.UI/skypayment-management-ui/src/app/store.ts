import {configureStore, ThunkAction, Action, combineReducers} from '@reduxjs/toolkit';
import counterReducer from '../features/counter/counterSlice';
import userInfoReducer from '../features/session-info/userInfoSlice';
import storage from "redux-persist/lib/storage";
import {FLUSH, PAUSE, PERSIST, persistReducer, PURGE, REGISTER, REHYDRATE} from "redux-persist";

const reducers = combineReducers({
    counter: counterReducer,
    userInfo:userInfoReducer
})
const persistConfig = {key: 'root', storage};
const persistedReducer = persistReducer(persistConfig, reducers)
export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: {
                ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
            },
        }),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType,
    RootState,
    unknown,
    Action<string>>;