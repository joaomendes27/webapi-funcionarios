import Axios from "axios";

const createAxios = Axios.create({
  baseURL: "https://localhost:7206",
});

export default createAxios;
