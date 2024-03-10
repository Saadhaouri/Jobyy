import { create } from "zustand";

type State = {
  isAuth: boolean;
};

type Actions = {
  logIn: () => void;
  logOut: () => void;
};
const authStore = create<State & Actions>((set) => ({
  isAuth: localStorage.getItem("token") ? true : false,
  logIn: () => set(() => ({ isAuth: true })),
  logOut: () => set(() => ({ isAuth: false })),
}));

export default authStore;
