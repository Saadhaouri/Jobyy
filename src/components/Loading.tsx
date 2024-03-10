import { Flex, Spin } from "antd";

const Loading = () => {
  return (
    <div className=" flex items-center">
      <Flex align="center" gap="middle">
        <Spin size="large" />
      </Flex>
      <span className=" text-blueColor text-h6 font-bold "> Joby</span>
    </div>
  );
};

export default Loading;
